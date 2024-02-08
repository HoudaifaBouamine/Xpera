package com.example.xpera.domain.model

import com.google.firebase.firestore.FieldValue

data class User(
    val displayName:String,
    val email:String,
    val photoUrl:String?,
    val createdAt:FieldValue
)
