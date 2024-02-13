import VehicleCard from '@/app/components/userdashboard/vehiclecard';
import { auth } from '@/auth'
import { signOut } from '@/auth';

const UserDashboard = async() => {
  const session = await auth();
  return (
    <div>
      {JSON.stringify(session)}
      <form action={async() => {
        "use server";

        await signOut();
      }}>
        <button>Sign Out</button>
      </form>

      <VehicleCard />
    </div>

  )
}

export default UserDashboard