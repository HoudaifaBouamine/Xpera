package com.example.expera.core
import com.example.expera.core.Utils.Companion.ErrorCode


sealed class Resource<T>(
    val data: T? =null,
    val error: ErrorCode? =null
){
    class Success<T>(data: T) : Resource<T>(data)
    class Error<T>(error:ErrorCode, data: T?=null) : Resource<T>(data,error)
    class Loading<T> : Resource<T>()
}