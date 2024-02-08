package com.example.xpera.presentation

import androidx.lifecycle.ViewModel
import com.example.xpera.domain.repository.AuthRepository
import dagger.hilt.android.lifecycle.HiltViewModel
import javax.inject.Inject

@HiltViewModel
class MainViewModel @Inject constructor(
    private val repository: AuthRepository
): ViewModel(){

    val currentUser get() =repository.currentUser
    val isUserAuthenticated   get() = repository.currentUser != null
    val isEmailVerified get()=repository.currentUser?.isEmailVerified ?: false
}