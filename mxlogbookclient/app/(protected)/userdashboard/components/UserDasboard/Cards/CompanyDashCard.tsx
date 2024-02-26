import Link from 'next/link';

export default function CompanyDashCard() {
    return (
        <div className=' w-6/12 ml-4 p-4 h-80 bg-bg-light rounded-xl'>
            <div className='flex justify-between items-center'>
              <h2 className='text-3xl'>Company</h2>
              <Link href="/userdashboard/vehicles" className='text-primary-200'>View More</Link>
            </div>
            <div className='h-full flex justify-center gap-x-32 mt-20'>
              <div className='flex flex-col items-center'>
                <p className='text-5xl'>5</p>
                <p className='text-xl font-thin'>Vehicles</p>
              </div>
              <div className='flex flex-col items-center'>
                <p className='text-5xl'>4</p>
                <p className='text-xl font-thin'>Items Assigned To You</p>
              </div>
            </div>
          </div>
    )
}