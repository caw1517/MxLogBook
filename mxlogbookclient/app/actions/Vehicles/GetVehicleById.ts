'use server'
import { auth } from "@/auth";

export async function GetVehicleById(vehicleId: number) {
    const session = await auth();

    try {
        const res = await fetch(`http://localhost:5035/api/Vehicles/${vehicleId}`, {
            method: "GET",
            headers: {
                'Authorization': `Bearer ${session?.user.accessToken}`,
                'Content-Type': 'application/json'
            }
        });

        const vehicle = await res.json();

        return vehicle;
    } catch(e) {
        throw e;
    }
}