package com.example.xpera.data.repository

import android.net.http.HttpException
import android.os.Build
import androidx.annotation.RequiresExtension
import com.example.xpera.core.CREATED_AT
import com.example.xpera.core.PHOTO_URL
import com.example.xpera.core.DISPLAY_NAME
import com.example.xpera.core.EMAIL
import com.example.xpera.core.Resource
import com.example.xpera.core.SIGN_IN_REQUEST
import com.example.xpera.core.SIGN_UP_REQUEST
import com.example.xpera.core.USERS
import com.example.xpera.core.Utils.Companion.ErrorCode
import com.example.xpera.domain.repository.AuthRepository
import com.google.android.gms.auth.api.identity.BeginSignInRequest
import com.google.android.gms.auth.api.identity.BeginSignInResult
import com.google.android.gms.auth.api.identity.SignInClient
import com.google.android.gms.common.api.ApiException
import com.google.firebase.auth.AuthCredential
import com.google.firebase.auth.FirebaseAuth
import com.google.firebase.auth.FirebaseAuthException
import com.google.firebase.auth.FirebaseAuthInvalidCredentialsException
import com.google.firebase.auth.FirebaseAuthUserCollisionException
import com.google.firebase.auth.FirebaseUser
import com.google.firebase.firestore.FieldValue
import com.google.firebase.firestore.FirebaseFirestore
import kotlinx.coroutines.tasks.await
import java.io.IOException
import javax.inject.Inject
import javax.inject.Named

class AuthRepositoryImpl @Inject constructor(
    private val oneTapClient: SignInClient,
    @Named(SIGN_IN_REQUEST)
    private val signUpRequest: BeginSignInRequest,
    @Named(SIGN_UP_REQUEST)
    private val signInRequest: BeginSignInRequest,
    private val auth: FirebaseAuth,
    private val firestore: FirebaseFirestore

):AuthRepository {
    override val currentUser  get() = auth.currentUser
    @RequiresExtension(extension = Build.VERSION_CODES.S, version = 7)
    override suspend fun signUserWithOneTap(): Resource<BeginSignInResult> {
        return try {

            val signInResult =oneTapClient.beginSignIn(signInRequest).await()
            Resource.Success(signInResult)
        } catch (e :Exception){
            try {
                val signUpResult=oneTapClient.beginSignIn(signUpRequest).await()
                Resource.Success(signUpResult)
            } catch (e: ApiException){
                Resource.Error(ErrorCode.NO_EMAIL_ON_DEVICE_ERROR)
            }catch (e: HttpException){
                Resource.Error(ErrorCode.UNKNOWN_ERROR)
            }catch (e: IOException){
                Resource.Error(ErrorCode.NO_INTERNET_ERROR)
            }catch (e: Exception){
                Resource.Error(ErrorCode.UNKNOWN_ERROR)
            }
        }
    }

    override suspend fun firebaseSignInWithCredential(googleCredential: AuthCredential): Resource<Boolean> {
        return try {
            val authResult=auth.signInWithCredential(googleCredential).await()
            val isNewUser=authResult.additionalUserInfo?.isNewUser?: false
            if (isNewUser){
                addUserToFirestore()
            }
            Resource.Success(true)
        } catch (e: FirebaseAuthException){
            Resource.Error(ErrorCode.UNKNOWN_ERROR)
        }
    }

    @RequiresExtension(extension = Build.VERSION_CODES.S, version = 7)
    override suspend fun firebaseSignInWithEmailAndPassword(
        email: String,
        password: String
    ): Resource<Boolean> {
        return try {
            auth.signInWithEmailAndPassword(email,password).await()
            Resource.Success(true)
        }catch (e: FirebaseAuthInvalidCredentialsException){
            Resource.Error(ErrorCode.INVALID_CREDENTIAL_ERROR)
        }catch (e: HttpException){
            Resource.Error(ErrorCode.UNKNOWN_ERROR)
        }catch (e: IOException){
            Resource.Error(ErrorCode.NO_INTERNET_ERROR)
        }catch (e: Exception){
            Resource.Error(ErrorCode.UNKNOWN_ERROR)
        }
    }


    @RequiresExtension(extension = Build.VERSION_CODES.S, version = 7)
    override suspend fun firebaseSignUpWithEmailAndPassword(
        fullName:String,
        email: String,
        password: String
    ): Resource<Boolean> {
        return try {
            auth.createUserWithEmailAndPassword(email,password).await()
            addUserToFirestore(fullName)
            Resource.Success(true)
        }catch (e: FirebaseAuthUserCollisionException){
            Resource.Error(ErrorCode.ALREADY_EXISTS_ERROR)
        }catch (e: HttpException){
            Resource.Error(ErrorCode.UNKNOWN_ERROR)
        }catch (e: IOException){
            Resource.Error(ErrorCode.NO_INTERNET_ERROR)
        }catch (e: Exception){
            Resource.Error(ErrorCode.UNKNOWN_ERROR)
        }
    }



    @RequiresExtension(extension = Build.VERSION_CODES.S, version = 7)
    override suspend fun sendEmailVerification(): Resource<Boolean> {
        return try {
            auth.currentUser?.sendEmailVerification()?.await()
            Resource.Success(true)
        }catch (e: HttpException){
            Resource.Error(ErrorCode.UNKNOWN_ERROR)
        }catch (e: IOException){
            Resource.Error(ErrorCode.NO_INTERNET_ERROR)
        }catch (e: Exception){
            Resource.Error(ErrorCode.UNKNOWN_ERROR)
        }
    }

    @RequiresExtension(extension = Build.VERSION_CODES.S, version = 7)
    override suspend fun sendPasswordResetEmail(email: String): Resource<Boolean> {
        return try {
            auth.sendPasswordResetEmail(email).await()
            Resource.Success(true)
        }catch (e: HttpException){
            Resource.Error(ErrorCode.UNKNOWN_ERROR)
        }catch (e: IOException){
            Resource.Error(ErrorCode.NO_INTERNET_ERROR)
        }catch (e: Exception){
            Resource.Error(ErrorCode.UNKNOWN_ERROR)
        }
    }

    @RequiresExtension(extension = Build.VERSION_CODES.S, version = 7)
    override suspend fun reloadFirebaseUser(): Resource<Boolean> {
        return try {
            auth.currentUser?.reload()?.await()
            Resource.Success(true)
        }catch (e: HttpException){
            Resource.Error(ErrorCode.UNKNOWN_ERROR)
        }catch (e: IOException){
            Resource.Error(ErrorCode.NO_INTERNET_ERROR)
        }catch (e: Exception){
            Resource.Error(ErrorCode.UNKNOWN_ERROR)
        }
    }

    private suspend fun addUserToFirestore(fullName:String="guest"){
        auth.currentUser?.apply {
            val user=toUser(fullName)
            firestore.collection(USERS).document(uid).set(user).await()
        }
    }


}

fun FirebaseUser.toUser(fullName:String) = mapOf(
    DISPLAY_NAME to if(displayName != null) displayName else fullName,
    EMAIL to email,
    PHOTO_URL to photoUrl?.toString(),
    CREATED_AT to FieldValue.serverTimestamp()
)