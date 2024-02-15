import VehicleCard from '@/app/components/userdashboard/vehiclecard';
import { auth } from '@/auth'
import { signOut } from '@/auth';
import UserDashTable from './components/UserDashTable';

const UserDashboard = async() => {
  const session = await auth();
  return (
    <div>
      <UserDashTable />
    </div>

  )
}

export default UserDashboard