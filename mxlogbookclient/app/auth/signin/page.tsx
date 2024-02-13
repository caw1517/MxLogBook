'use client'
import React from 'react'
import Airplane from '@/public/airplane.svg'
import Image from 'next/image'
import FormComp from './components/form'
import { useAppSelector } from '../../store/store'
import Link from 'next/link'
const SignIn = () => {
  //State
  const errorState = useAppSelector((state) => state.auth.error);

  return (
    <div className=" w-full h-screen relative flex flex-col justify-center items-center top-1/4">
      <div className='flex justify-center relative'>
        <Link className='absolute left-0 bottom-full text-lg' href="/">Go Back</Link>
        {errorState ? <p className='text-red-600 text-2xl absolute bottom-full mb-2'>{errorState}</p> : null}
        <div className=" h-[545px] w-[456px] bg-dark-200 rounded-2xl flex flex-col items-center gap-4">
            <Image src={Airplane} alt='Airplane' />
            <h2 className="text-5xl font-semibold mb-3">Sign In</h2>
            <FormComp />
        </div>
      </div>
    </div>
  )
}

export default SignIn