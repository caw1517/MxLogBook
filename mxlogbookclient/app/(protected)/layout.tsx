import React from 'react'
import { Navbar } from '../components/navbar/navbar';
import UserNavbar from '../components/navbar/UserNavbar';
import Sidebar from './userdashboard/components/Sidebar';

const AuthLayout = ({ children }: {children: React.ReactNode}) => {
  return (
    <div>
        <Sidebar />
        <UserNavbar />
        {children}
    </div>
  )
}

export default AuthLayout;