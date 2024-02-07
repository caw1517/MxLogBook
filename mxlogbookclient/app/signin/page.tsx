'use client'
import React from 'react'
import { FormEvent } from 'react'
import Airplane from '../../public/airplane.svg'
import Image from 'next/image'
import FormComp from './components/form'

const SignIn = () => {
  return (
    <div className=" w-full h-screen flex justify-center items-center">
        <div className=" h-[545px] w-[456px] bg-dark-200 rounded-2xl flex flex-col items-center gap-4">
            <Image src={Airplane} alt='Airplane' />
            <h2 className="text-5xl font-semibold mb-3">Sign In</h2>

            <FormComp />
        </div>
    </div>
  )
}

export default SignIn