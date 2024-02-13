'use client'
import React from 'react'
import Link from 'next/link'
import Image from 'next/image'

import menu from '@/public/Menu.svg'
import { useAppSelector } from '@/app/store/store'

export const Navbar = () => {
  const authState = useAppSelector((state) => state.auth.authState);

  return (
    <div className="flex justify-between w-screen p-10">
      <div className="flex gap-10">
        <Image src={menu} alt="Burger Menu"/>
        <Link href="/">MxLogBook</Link>
      </div>
      <div className="flex gap-10">
        <Link href="/auth/signin">Sign In</Link>
        <Link href="/register">Create Account</Link>
        <p>{authState ? "Logged in" : "Logged Out"}</p>
      </div>
    </div>
  )
}
