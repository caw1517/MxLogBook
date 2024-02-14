'use server'
import { auth } from "@/auth";

export async function GetVehiclesByUser() {
    const session = await auth();

    try {
        const res = await fetch(`http://localhost:5035/api/Vehicles`, {
            method: "GET",
            headers: {
                'Authorization': `Bearer ${session?.user.accessToken}`,
                'Content-Type': 'application/json'
            }
        })

        const vehicles = await res.json();
        

        return vehicles;
    } catch (e) {
        throw e;
    }
}