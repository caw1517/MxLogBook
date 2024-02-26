'use client'
import Airplane from '@/public/airplane.svg'
import Image from 'next/image'
import { useState } from 'react';

export default function Sidebar() {
    const [isOpen, setIsOpen] = useState(false);
    const onMouseOver = () => setIsOpen(true);
    const onMouseOff = () => setIsOpen(false);
    return(
        <div className={`${isOpen ?  'w-72' : 'w-20'} h-screen bg-bg-light fixed pl-2 pt-7 duration-150`} onMouseEnter={onMouseOver} onMouseLeave={onMouseOff}>
            <div className='flex gap-x-4 items-center'>
                <Image src={Airplane} alt='Airplane' width={70} />
                <p className={`text-white origin-left font-medium text-2xl duration-100 ${!isOpen && "scale-0"} `}>MxLogBook</p>
            </div>
        </div>
        // <div className='fixed w-20 h-screen bg-bg-light flex justify-center items-start'>
        //     asi
        // </div>
        // <aside className='h-screen'>
        //     <nav className='h-full flex flex-col bg-bg-light border-r'>
        //         <div className='p-4 pb-2 flex justify-between items center'>
        //         </div>

        //         <ul className='flex-1 px-3'>{children}</ul>
        //     </nav>
        // </aside>
    )
}