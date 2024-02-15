import React from 'react'
import Link from 'next/link'
import Image from 'next/image'

import menu from '@/public/Menu.svg'
import { useAppSelector } from '@/app/store/store'

import { auth, signOut } from '@/auth'

export const Navbar =  async () => {
  const session = await auth();

  return (
    <div className="flex justify-between w-screen p-10">
      <div className="flex gap-10">
        <Image src={menu} alt="Burger Menu"/>

        <Link href={session ? "/userdashboard" :"/"}>MxLogBook</Link>
      </div>
      <div className="flex gap-10">
        {session ? 
          <form action={async() => {
            "use server";
    
            await signOut();
          }}>
            <button type="submit">Sign Out</button>
          </form>
          : 
          <Link href="/auth/signin">Sign In</Link>}

          {session ? 
            <Link href="/auth/accountsettings">Account</Link>
            :
            <Link href="/register">Create Account</Link>
          }
      </div>
    </div>
  )
}
