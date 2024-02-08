package com.example.xpera.presentation.auth

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.navigation.fragment.findNavController
import com.example.xpera.R
import com.example.xpera.databinding.FragmentSuccessBinding
import dagger.hilt.android.AndroidEntryPoint

@AndroidEntryPoint
class SuccessFragment : Fragment() {

    private var binding: FragmentSuccessBinding? = null

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        binding = FragmentSuccessBinding.inflate(inflater, container, false)
        return binding?.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        binding?.apply {
            cont.setOnClickListener {
                findNavController().navigate(R.id.action_successFragment_to_home_nav_graph)
            }
        }
    }


}