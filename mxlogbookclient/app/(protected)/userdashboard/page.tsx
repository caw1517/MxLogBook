import { auth } from '@/auth'
import VehicleDashCard from './components/UserDasboard/Cards/VehicleDashCard';
import CompanyDashCard from './components/UserDasboard/Cards/CompanyDashCard';
import DashboardTaskCard from './components/UserDasboard/Cards/DashbaordTaskCard';

const UserDashboard = async() => {
  const session = await auth();
  return (
    <div className='w-screen h-screen flex justify-center'>
      <div className='w-2/3'>
        <div className='w-full flex justify-between'>
          <VehicleDashCard />
          <CompanyDashCard />
        </div>
        <div>
          <DashboardTaskCard />
        </div>
      </div>
    </div>


  )
}

export default UserDashboard