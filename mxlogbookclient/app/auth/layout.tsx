import React from 'react'
import { Navbar } from '../components/navbar/navbar';

const AuthLayout = ({ children }: {children: React.ReactNode}) => {
  return (
    <div>
      {children}
    </div>
  )
}

export default AuthLayout;