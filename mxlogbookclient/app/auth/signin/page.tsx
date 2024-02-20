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
    <div className=" w-full h-screen relative flex justify-end items-center">
      <div className='w-2/3 h-[90%] bg-bg-dark ml-10 rounded-2xl flex justify-center items-center'>
        <div className='h-[350px] w-[350px] rounded-[50%] border-primary-200 border-2 p-4'>
          <div className='bg-bg-light w-full h-full rounded-[50%] flex justify-center items-center'>
            <Image src={Airplane} alt='Airplane' height={325} />
          </div>
        </div>
      </div>
      <div className=' w-1/3 px-36'>
        {/* <Image src={Airplane} alt='Airplane' width={100}/> */}
        <h2 className='text-2xl font-extralight'>Welcome to MXLogBook!</h2>
        <p>Please sign in to your account to get started</p>
        <FormComp />
      </div>

      {/* <div className='flex justify-center relative'>
        <Link className='absolute left-0 bottom-full text-lg' href="/">Go Back</Link>
        {errorState ? <p className='text-red-600 text-2xl absolute bottom-full mb-2'>{errorState}</p> : null}
        <div className=" h-[545px] w-[456px] bg-dark-200 rounded-2xl flex flex-col items-center gap-4">
            <Image src={Airplane} alt='Airplane' />
            <h2 className="text-5xl font-semibold mb-3">Sign In</h2>
            <FormComp />
        </div>
      </div> */}
    </div>
  )
}

export default SignIn