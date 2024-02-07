package com.example.expera.presentation.auth

import android.content.ActivityNotFoundException
import android.content.Intent
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.fragment.app.activityViewModels
import androidx.navigation.fragment.findNavController
import com.example.expera.R
import com.example.expera.core.EMAIL_NOT_VERIFIED_MESSAGE
import com.example.expera.core.Resource
import com.example.expera.core.UNKNOWN_ERROR_MESSAGE
import com.example.expera.core.VERIFY_EMAIL_MESSAGE
import com.example.expera.databinding.FragmentVerificationEmailBinding
import dagger.hilt.android.AndroidEntryPoint


@AndroidEntryPoint
class VerificationEmailFragment : Fragment() {

    private var binding: FragmentVerificationEmailBinding? = null
    private val viewModel: AuthViewModel by activityViewModels()

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        binding = FragmentVerificationEmailBinding.inflate(inflater, container, false)
        return binding?.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        binding?.apply {

            openEmailApp.setOnClickListener {
                openEmailApp()
            }

            cont.setOnClickListener {
                viewModel.reloadUser()
            }

            sendAgain.setOnClickListener {
                viewModel.sendEmailVerification()
            }
        }

        viewModel.apply {
            reloadUserResponse.observe(viewLifecycleOwner) {
                when (it) {
                    is Resource.Loading -> TODO()// showProgressbar()
                    is Resource.Success -> {
                        //hideProgressbar()
                        if (viewModel.isEmailVerified)
                            findNavController().navigate(R.id.action_verificationEmailFragment_to_successFragment)
                        else {
                            Toast.makeText(requireContext(), EMAIL_NOT_VERIFIED_MESSAGE,Toast.LENGTH_SHORT).show()
                        }
                    }
                    else -> {
                        //hideProgressbar()
                        Toast.makeText(requireContext(), UNKNOWN_ERROR_MESSAGE,Toast.LENGTH_SHORT).show()
                    }
                }
            }

            sendEmailVerificationResponse.observe(viewLifecycleOwner) {
                when (it) {
                    is Resource.Loading -> TODO()// showProgressbar()
                    is Resource.Success -> {
                        //hideProgressbar()
                        Toast.makeText(requireContext(), VERIFY_EMAIL_MESSAGE,Toast.LENGTH_SHORT).show()
                    }
                    is Resource.Error -> {
                        //hideProgressbar()
                        Toast.makeText(requireContext(), UNKNOWN_ERROR_MESSAGE,Toast.LENGTH_SHORT).show()
                    }
                }
            }

        }
    }


    private fun openEmailApp() {
        val intent = Intent(Intent.ACTION_MAIN)
        intent.addCategory(Intent.CATEGORY_APP_EMAIL)
        try {
            startActivity(Intent.createChooser(intent, "Choose your Email App"))
        } catch (e: ActivityNotFoundException) {
            Toast.makeText(requireContext(), "Email app not found", Toast.LENGTH_SHORT).show()
        }
    }

    override fun onDestroyView() {
        super.onDestroyView()
        binding = null
    }


}