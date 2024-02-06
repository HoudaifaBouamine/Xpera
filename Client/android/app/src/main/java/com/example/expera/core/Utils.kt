package com.example.expera.core

import android.annotation.SuppressLint
import android.content.res.loader.ResourcesLoader
import com.google.common.io.Resources


class Utils {


    companion object{

        enum class ErrorCode{
            INVALID_CREDENTIAL_ERROR,
            UNKNOWN_ERROR,
            NO_INTERNET_ERROR,
            ALREADY_EXISTS_ERROR,
            NO_EMAIL_ON_DEVICE_ERROR
        }
        //private val resString=android.content.res.Resources.getSystem()


    }
}