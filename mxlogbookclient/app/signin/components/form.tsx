'use client';
import { LoginRedirect } from '@/app/actions/LoginRedirect';
import path from 'path';
import { FormEvent } from 'react'
import React from 'react'
import { useState } from 'react';

const FormComp = () => {
    const [error, setError] = useState();

    async function HandleSubmit(event: FormEvent<HTMLFormElement>) {
        event.preventDefault();

        const formData = new FormData(event.currentTarget);

        //Set Target data
        const email = formData.get('email');
        const password = formData.get('password');

        //Call the api - Move the base api string somewhere else
        const response = await fetch('/api/auth/login', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({email, password})
        });

        const data = await response.json();

        console.log(data);

        if(data.error) {
          setError(data.error);
        } else {
          LoginRedirect();
        }
    }

  return (
    <form onSubmit={HandleSubmit}  className="className='w-full flex flex-col items-center gap-4">
        <input type="text" placeholder='Email' name='email' className='w-[328px] bg-inherit border-gray-300 border-[1px] h-[48px] p-2 focus:outline-none'/>
        <input type="text" placeholder='Password' name="password" className='w-[328px] bg-inherit border-gray-300 border-[1px] h-[48px] p-2 focus:outline-none'/>
        <div className="flex justify-between w-[328px] -m-3">
            <p>Forgot Password</p>
            <p>Create Account</p>
        </div>
        <button className='w-[328px] bg-primary-200 h-[48px] m-8' type='submit'>Sign In</button>
    </form>
  )
}

export default FormComp