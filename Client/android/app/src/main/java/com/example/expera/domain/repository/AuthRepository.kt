package com.example.expera.domain.repository

import com.example.expera.core.Resource
import com.google.android.gms.auth.api.identity.BeginSignInResult
import com.google.firebase.auth.AuthCredential
import com.google.firebase.auth.FirebaseUser

interface AuthRepository {


    val currentUser: FirebaseUser?

    suspend fun signUserWithOneTap(): Resource<BeginSignInResult>

    suspend fun firebaseSignInWithCredential(googleCredential: AuthCredential): Resource<Boolean>

    suspend fun firebaseSignInWithEmailAndPassword(email:String,password:String): Resource<Boolean>

    suspend fun sendPasswordResetEmail(email: String): Resource<Boolean>

    suspend fun firebaseSignUpWithEmailAndPassword(fullName:String,email:String,password:String): Resource<Boolean>

    suspend fun sendEmailVerification(): Resource<Boolean>

    suspend fun reloadFirebaseUser(): Resource<Boolean>
}