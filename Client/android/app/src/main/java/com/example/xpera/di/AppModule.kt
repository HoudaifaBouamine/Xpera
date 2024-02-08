package com.example.xpera.di

import android.app.Application
import android.content.Context
import com.example.xpera.R
import com.example.xpera.core.SIGN_IN_REQUEST
import com.example.xpera.core.SIGN_UP_REQUEST
import com.google.android.gms.auth.api.identity.BeginSignInRequest
import com.google.android.gms.auth.api.identity.Identity
import com.google.firebase.auth.ktx.auth
import com.google.firebase.firestore.ktx.firestore
import com.google.firebase.ktx.Firebase
import dagger.Module
import dagger.Provides
import dagger.hilt.InstallIn
import dagger.hilt.android.qualifiers.ApplicationContext
import dagger.hilt.components.SingletonComponent
import javax.inject.Named
import javax.inject.Singleton


@Module
@InstallIn(SingletonComponent::class)
object AppModule {

    @Singleton
    @Provides
    fun provideFirebaseAuth()= Firebase.auth

    @Singleton
    @Provides
    fun provideFirebaseFirestore()= Firebase.firestore



    @Singleton
    @Provides
    @Named(SIGN_IN_REQUEST)
    fun provideSignInRequest(app: Application)= BeginSignInRequest.builder()
        .setGoogleIdTokenRequestOptions(
            BeginSignInRequest.GoogleIdTokenRequestOptions.builder()
                .setSupported(true)
                .setServerClientId(app.getString(R.string.your_web_client_id))
                .setFilterByAuthorizedAccounts(true)
                .build()
        )
        .setAutoSelectEnabled(true)
        .build()

    @Singleton
    @Provides
    @Named(SIGN_UP_REQUEST)
    fun provideSignUpRequest(app: Application)= BeginSignInRequest.builder()
        .setGoogleIdTokenRequestOptions(
            BeginSignInRequest.GoogleIdTokenRequestOptions.builder()
                .setSupported(true)
                .setServerClientId(app.getString(R.string.your_web_client_id))
                .setFilterByAuthorizedAccounts(false)
                .build()
        )
        .build()

    @Singleton
    @Provides
    fun provideOneTapClient(
        @ApplicationContext
        context: Context
    )= Identity.getSignInClient(context)


}