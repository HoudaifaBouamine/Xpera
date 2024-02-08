package com.example.xpera.presentation.auth

import android.app.Activity
import android.os.Bundle
import android.util.Patterns
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.activity.result.IntentSenderRequest
import androidx.activity.result.contract.ActivityResultContracts
import androidx.fragment.app.viewModels
import androidx.navigation.fragment.findNavController
import com.example.xpera.R
import com.example.xpera.core.EMAIL_ALREADY_EXIST_MESSAGE
import com.example.xpera.core.Utils.Companion.ErrorCode
import com.example.xpera.core.NO_EMAIL_FOUND_MESSAGE
import com.example.xpera.core.Resource
import com.example.xpera.core.UNKNOWN_ERROR_MESSAGE
import com.example.xpera.databinding.FragmentSignupBinding
import com.google.android.gms.auth.api.identity.BeginSignInResult
import com.google.android.gms.common.api.ApiException
import com.google.firebase.auth.GoogleAuthProvider
import dagger.hilt.android.AndroidEntryPoint

@AndroidEntryPoint
class SignupFragment : Fragment() {

    private val viewModel : AuthViewModel by viewModels()
    private var binding: FragmentSignupBinding? = null

    private val launcher = registerForActivityResult(
        ActivityResultContracts.StartIntentSenderForResult()
    ){result ->
        if (result.resultCode == Activity.RESULT_OK){
            try {
                val credential=viewModel.oneTapClient.getSignInCredentialFromIntent(result.data)
                val googleIdToken= credential.googleIdToken
                val googleCredentials = GoogleAuthProvider.getCredential(googleIdToken,null)
                viewModel.signInWithGoogle(googleCredentials)
            }catch (e: ApiException){
                Toast.makeText(requireContext(), NO_EMAIL_FOUND_MESSAGE, Toast.LENGTH_SHORT).show()
            }
        }
    }



    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        binding = FragmentSignupBinding.inflate(inflater, container, false)
        return binding?.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        binding?.apply {

            signup.setOnClickListener {
                val fullName =fullName.text?.trim().toString()
                val email =email.text?.trim().toString()
                val password =password.text?.trim().toString()
                if (fullName.trim().isEmpty()) {
                    inputLayoutFullName.error = "Required."
                }else if (email.trim().isEmpty()){
                    inputLayoutFullName.error=null
                    inputLayoutFullName.clearFocus()
                    inputLayoutEmail.error="Required."
                }else if (!Patterns.EMAIL_ADDRESS.matcher(email).matches()) {
                    inputLayoutEmail.error = "Incorrect format."
                }else if (password.count() < 7){
                    inputLayoutFullName.error=null
                    inputLayoutFullName.clearFocus()
                    inputLayoutEmail.error=null
                    inputLayoutEmail.clearFocus()
                    inputLayoutPassword.error="Must be more than 7 char."
                }else{
                    inputLayoutPassword.error=null
                    inputLayoutPassword.clearFocus()
                    viewModel.signUpWithEmailAndPassword(fullName,email, password)
                }
            }

            signWithGoogle.setOnClickListener {
                viewModel.oneTapSignIn()
            }

            login.setOnClickListener {
                findNavController().popBackStack()
            }

        }

        viewModel.apply {

            oneTapSignInResponse.observe(viewLifecycleOwner) {
                when(it){
                    is Resource.Loading -> showProgressbar()
                    is Resource.Success -> {
                        hideProgressbar()
                        it.data?.let { result -> launch(result)
                        }
                    }
                    is Resource.Error ->{
                        hideProgressbar()
                        if (it.error == ErrorCode.NO_EMAIL_ON_DEVICE_ERROR){
                            Toast.makeText(requireContext(), NO_EMAIL_FOUND_MESSAGE,Toast.LENGTH_SHORT).show()
                        }
                    }
                }
            }

            signInWithGoogleResponse.observe(viewLifecycleOwner) {
                when(it){
                    is Resource.Loading -> showProgressbar()
                    is Resource.Success -> {
                        hideProgressbar()
                        findNavController().navigate(R.id.action_signupFragment_to_home_nav_graph)
                    }
                    is Resource.Error ->{
                        hideProgressbar()
                        Toast.makeText(requireContext(), UNKNOWN_ERROR_MESSAGE,Toast.LENGTH_SHORT).show()
                    }
                }
            }

            signUpWithEmailAndPasswordResponse.observe(viewLifecycleOwner) {
                when(it){
                    is Resource.Loading -> showProgressbar()
                    is Resource.Success -> {
                        hideProgressbar()
                        viewModel.sendEmailVerification()
                    }
                    else -> {
                        hideProgressbar()
                        if (it.error ==ErrorCode.ALREADY_EXISTS_ERROR){
                            Toast.makeText(requireContext(), EMAIL_ALREADY_EXIST_MESSAGE,Toast.LENGTH_SHORT).show()
                        }
                    }
                }
            }

            sendEmailVerificationResponse.observe(viewLifecycleOwner) {
                when(it){
                    is Resource.Loading -> showProgressbar()
                    is Resource.Success -> {
                        hideProgressbar()
                        findNavController().navigate(R.id.action_signupFragment_to_verificationEmailFragment)
                    }
                    else -> {
                        hideProgressbar()
                        Toast.makeText(requireContext(), UNKNOWN_ERROR_MESSAGE,Toast.LENGTH_SHORT).show()
                    }
                }
            }

        }


    }

    private fun launch(signInResult: BeginSignInResult) {
        val intent = IntentSenderRequest.Builder(signInResult.pendingIntent.intentSender).build()
        launcher.launch(intent)
    }

    private fun showProgressbar() {
        binding?.apply {
            progressIndicator.visibility = View.VISIBLE
            grayOverlay.visibility =View.VISIBLE
        }

    }

    private fun hideProgressbar() {
        binding?.apply {
            progressIndicator.visibility = View.INVISIBLE
            grayOverlay.visibility =View.INVISIBLE
        }
    }

    override fun onDestroyView() {
        super.onDestroyView()
        binding = null
    }



}