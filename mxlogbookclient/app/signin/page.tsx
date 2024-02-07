import React from 'react'
import Airplane from '../../public/airplane.svg'
import Image from 'next/image'

const SignIn = () => {
  return (
    <div className=" w-full h-screen flex justify-center items-center">
        <div className=" h-[545px] w-[456px] bg-dark-200 rounded-2xl flex flex-col items-center gap-4">
            <Image src={Airplane} alt='Airplane' />
            <h2 className="text-5xl font-semibold mb-3">Sign In</h2>
            <input type="text" placeholder='Email or Username' className='w-[328px] bg-inherit border-gray-300 border-[1px] h-[48px] p-2 focus:outline-none'/>
            <input type="text" placeholder='Password' className='w-[328px] bg-inherit border-gray-300 border-[1px] h-[48px] p-2 focus:outline-none'/>
            <div className="flex justify-between w-[328px] -m-3">
                <p>Forgot Password</p>
                <p>Create Account</p>
            </div>
            <button className='w-[328px] bg-primary-200 h-[48px] m-8'>Sign In</button>

        </div>
    </div>
  )
}

export default SignIn