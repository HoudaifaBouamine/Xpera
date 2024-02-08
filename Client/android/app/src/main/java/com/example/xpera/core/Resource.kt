package com.example.xpera.core
import com.example.xpera.core.Utils.Companion.ErrorCode


sealed class Resource<T>(
    val data: T? =null,
    val error: ErrorCode? =null
){
    class Success<T>(data: T) : Resource<T>(data)
    class Error<T>(error:ErrorCode, data: T?=null) : Resource<T>(data,error)
    class Loading<T> : Resource<T>()
}