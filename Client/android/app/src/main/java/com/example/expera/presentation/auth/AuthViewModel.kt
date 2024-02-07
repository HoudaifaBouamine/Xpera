package com.example.expera.presentation.auth

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.expera.core.Resource
import com.example.expera.domain.repository.AuthRepository
import com.google.android.gms.auth.api.identity.BeginSignInResult
import com.google.android.gms.auth.api.identity.SignInClient
import com.google.firebase.auth.AuthCredential
import dagger.hilt.android.lifecycle.HiltViewModel
import kotlinx.coroutines.launch
import javax.inject.Inject

@HiltViewModel
class AuthViewModel @Inject constructor(
    private val repository: AuthRepository,
    val oneTapClient: SignInClient
):ViewModel() {

    val isEmailVerified get() = repository.currentUser?.isEmailVerified ?: false


    //variables

    private val _oneTapSignInResponse = MutableLiveData<Resource<BeginSignInResult>>()
    val oneTapSignInResponse: LiveData<Resource<BeginSignInResult>> = _oneTapSignInResponse

    private val _signInWithGoogleResponse = MutableLiveData<Resource<Boolean>>()
    val signInWithGoogleResponse: LiveData<Resource<Boolean>> = _signInWithGoogleResponse

    private val _signInWithEmailAndPasswordResponse = MutableLiveData<Resource<Boolean>>()
    val signInWithEmailAndPasswordResponse: LiveData<Resource<Boolean>> =
        _signInWithEmailAndPasswordResponse

    private val _signUpWithEmailAndPasswordResponse = MutableLiveData<Resource<Boolean>>()
    val signUpWithEmailAndPasswordResponse: LiveData<Resource<Boolean>> =
        _signUpWithEmailAndPasswordResponse

    private val _sendEmailVerificationResponse = MutableLiveData<Resource<Boolean>>()
    val sendEmailVerificationResponse: LiveData<Resource<Boolean>> = _sendEmailVerificationResponse

    private val _reloadUserResponse = MutableLiveData<Resource<Boolean>>()
    val reloadUserResponse: LiveData<Resource<Boolean>> = _reloadUserResponse


    private val _sendPasswordResetEmailResponse = MutableLiveData<Resource<Boolean>>()
    val sendPasswordResetEmailResponse: LiveData<Resource<Boolean>> =
        _sendPasswordResetEmailResponse



    //functions

    fun oneTapSignIn() = viewModelScope.launch {
        _oneTapSignInResponse.postValue(Resource.Loading())
        _oneTapSignInResponse.postValue(repository.signUserWithOneTap())
    }



    fun signInWithGoogle(googleCredential: AuthCredential) = viewModelScope.launch {
        _signInWithGoogleResponse.postValue(Resource.Loading())
        _signInWithGoogleResponse.postValue(repository.firebaseSignInWithCredential(googleCredential))
    }



    fun signInWithEmailAndPassword(email: String, password: String) = viewModelScope.launch {
        _signInWithEmailAndPasswordResponse.postValue(Resource.Loading())
        _signInWithEmailAndPasswordResponse.postValue(
            repository.firebaseSignInWithEmailAndPassword(
                email,
                password
            )
        )
    }



    fun signUpWithEmailAndPassword(fullName:String,email: String, password: String) = viewModelScope.launch {
        _signUpWithEmailAndPasswordResponse.postValue(Resource.Loading())
        _signUpWithEmailAndPasswordResponse.postValue(
            repository.firebaseSignUpWithEmailAndPassword(
                fullName,
                email,
                password
            )
        )
    }


    fun sendEmailVerification() = viewModelScope.launch {
        _sendEmailVerificationResponse.postValue(Resource.Loading())
        _sendEmailVerificationResponse.postValue(repository.sendEmailVerification())
    }



    fun reloadUser() = viewModelScope.launch {
        _reloadUserResponse.postValue(Resource.Loading())
        _reloadUserResponse.postValue((repository.reloadFirebaseUser()))
    }



    fun sendPasswordResetEmail(email: String) = viewModelScope.launch {
        _sendPasswordResetEmailResponse.postValue(Resource.Loading())
        _sendPasswordResetEmailResponse.postValue(repository.sendPasswordResetEmail(email))
    }
}