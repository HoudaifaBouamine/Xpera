package com.example.expera.presentation.auth

import android.app.Activity
import android.os.Bundle
import android.util.Patterns
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import com.example.expera.core.Utils.Companion.ErrorCode
import androidx.activity.result.IntentSenderRequest
import androidx.activity.result.contract.ActivityResultContracts
import androidx.fragment.app.viewModels
import androidx.navigation.fragment.findNavController
import com.example.expera.R
import com.example.expera.core.CREDENTIAL_INCORRECT_MESSAGE
import com.example.expera.core.NO_EMAIL_FOUND_MESSAGE
import com.example.expera.core.RESET_PASSWORD_MESSAGE
import com.example.expera.core.Resource
import com.example.expera.core.UNKNOWN_ERROR_MESSAGE
import com.example.expera.databinding.FragmentLoginBinding
import com.google.android.gms.auth.api.identity.BeginSignInResult
import com.google.android.gms.common.api.ApiException
import com.google.firebase.auth.GoogleAuthProvider
import dagger.hilt.android.AndroidEntryPoint


@AndroidEntryPoint
class LoginFragment : Fragment() {

    private val viewModel: AuthViewModel by viewModels()
    private var binding: FragmentLoginBinding? = null


    private val launcher = registerForActivityResult(
        ActivityResultContracts.StartIntentSenderForResult()
    ) { result ->
        if (result.resultCode == Activity.RESULT_OK) {
            try {
                val credential = viewModel.oneTapClient.getSignInCredentialFromIntent(result.data)
                val googleIdToken = credential.googleIdToken
                val googleCredentials = GoogleAuthProvider.getCredential(googleIdToken, null)
                viewModel.signInWithGoogle(googleCredentials)
            } catch (e: ApiException) {
                Toast.makeText(requireContext(), CREDENTIAL_INCORRECT_MESSAGE,Toast.LENGTH_SHORT).show()
            }

        }


    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        binding = FragmentLoginBinding.inflate(inflater, container, false)
        return binding?.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        binding?.apply {
            signWithGoogle.setOnClickListener {
                viewModel.oneTapSignIn()
            }

            forgotPassword.setOnClickListener {
                viewModel.sendPasswordResetEmail("ishaqmehdi60@gmail.com")
            }

            signup.setOnClickListener {
                findNavController().navigate(R.id.action_loginFragment_to_signupFragment)
            }


            login.setOnClickListener {
                val email = binding?.email?.text?.trim().toString()
                val password = binding?.password?.text?.trim().toString()
                if (email.trim().isEmpty()) {
                    binding?.inputLayoutEmail?.error = "Required."
                } else if (!Patterns.EMAIL_ADDRESS.matcher(email).matches()) {
                    binding?.inputLayoutEmail?.error = "Incorrect format."
                } else if (password.count() < 7) {
                    binding?.inputLayoutEmail?.error = null
                    binding?.inputLayoutEmail?.clearFocus()
                    binding?.inputLayoutPassword?.error = "Must be more than 7 char."
                } else {
                    binding?.inputLayoutEmail?.error = null
                    binding?.inputLayoutPassword?.error = null
                    binding?.inputLayoutEmail?.clearFocus()
                    binding?.inputLayoutPassword?.clearFocus()
                    viewModel.signInWithEmailAndPassword(email, password)
                }
            }
        }

        viewModel.apply {

            oneTapSignInResponse.observe(viewLifecycleOwner) {
                when (it) {
                    is Resource.Loading -> TODO()// showProgressbar()
                    is Resource.Success -> {
                        //hideProgressbar()
                        it.data?.let { result ->
                            launch(result)
                        }
                    }
                    else -> {
                        //hideProgressbar()
                        if (it.error == ErrorCode.NO_EMAIL_ON_DEVICE_ERROR) {
                            Toast.makeText(requireContext(), NO_EMAIL_FOUND_MESSAGE,Toast.LENGTH_SHORT).show()
                        }
                    }
                }
            }

            signInWithGoogleResponse.observe(viewLifecycleOwner) {
                when (it) {
                    is Resource.Loading -> TODO()// showProgressbar()
                    is Resource.Success -> {
                        //hideProgressbar()
                        findNavController().navigate(R.id.action_loginFragment_to_home_nav_graph)
                    }

                    else -> {
                        //hideProgressbar()
                        Toast.makeText(requireContext(), UNKNOWN_ERROR_MESSAGE,Toast.LENGTH_SHORT).show()
                    }
                }
            }

            signInWithEmailAndPasswordResponse.observe(viewLifecycleOwner) {
                when (it) {
                    is Resource.Loading -> TODO()// showProgressbar()
                    is Resource.Success -> {
                        //hideProgressbar()
                        if (viewModel.isEmailVerified)
                            findNavController().navigate(R.id.action_loginFragment_to_home_nav_graph)
                        else {
                            findNavController().navigate(R.id.action_loginFragment_to_verificationEmailFragment)
                        }
                    }
                    else -> {
                        //hideProgressbar()
                        if (it.error == ErrorCode.INVALID_CREDENTIAL_ERROR) {
                            Toast.makeText(requireContext(), CREDENTIAL_INCORRECT_MESSAGE,Toast.LENGTH_SHORT).show()
                        }
                    }
                }
            }

            sendPasswordResetEmailResponse.observe(viewLifecycleOwner) {
                when (it) {
                    is Resource.Loading -> TODO()//showprogress
                    is Resource.Success -> {
                        //hideProgressbar()
                        Toast.makeText(requireContext(), RESET_PASSWORD_MESSAGE,Toast.LENGTH_SHORT).show()
                    }
                    else -> {
                        //hideProgressbar()
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

    override fun onDestroyView() {
        super.onDestroyView()
        binding = null

    }


}