'use client';
import { FormEvent } from 'react'
import React from 'react'
import { signIn } from 'next-auth/react';
import { useRouter, useSearchParams } from 'next/navigation';
import { setAuthState, setError } from '@/app/slices/authslice';
import { useAppDispatch, useAppSelector } from '@/app/store/store';
import { useDispatch } from 'react-redux';
import { Login } from '@/app/actions/Login';

const FormComp = () => {
    //Global State
    const authState = useAppSelector((state) => state.auth.authState)
    const errorState = useAppSelector((state) => state.auth.error)

    //Dispatch
    const dispatch = useAppDispatch();


    function HandleSubmit(event: FormEvent<HTMLFormElement>) {
        event.preventDefault();

        const formData = new FormData(event.currentTarget);

        //Set Target data
        const email = formData.get('email')?.toString();
        const password = formData.get('password')?.toString();

        console.log(email, password, ": Sent");

        Login(email, password).then(data => {
          if(data?.error) {
            dispatch(setError(data.error));
          } else {
            console.log(data)
          }
        })

    }

  return (
    <form onSubmit={HandleSubmit}  className="className='w-full flex flex-col items-start gap-8 my-8">
        <input type="text" placeholder='Email' name='email' className='w-full bg-inherit border-gray-300 border-[1px] h-[36px] rounded-lg p-2 focus:outline-none'/>
        <input type="text" placeholder='Password' name="password" className='w-full bg-inherit border-gray-300 border-[1px] h-[36px] rounded-lg p-2 focus:outline-none'/>
        <div className="flex justify-between w-full -top-6 relative">
            <p>Create Account</p>
            <p className='text-primary-200'>Forgot Password?</p>
        </div>

        <button className='w-full bg-primary-200 h-[48px] relative -top-6' type='submit' >Sign In</button>
    </form>
  )
}

export default FormComp