import Airplane from '@/public/airplane.svg'
import Image from 'next/image'

export default function Sidebar() {
    return(
        <div className='fixed w-20 h-screen bg-bg-light flex justify-center items-start'>
            <Image src={Airplane} alt='airplane' height={60} />
        </div>
    )
}