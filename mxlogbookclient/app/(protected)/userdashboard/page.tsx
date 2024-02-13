import VehicleCard from '@/app/components/userdashboard/vehiclecard';
import { auth } from '@/auth'
import { signOut } from '@/auth';

const UserDashboard = async() => {
  const session = await auth();
  return (
    <div>
      <VehicleCard />
    </div>

  )
}

export default UserDashboard