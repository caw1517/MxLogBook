'use server'

import {auth} from "@/auth";

export async function GetLogsByUser() {
    const session = await auth();

    try {
        const res = await fetch(`http://localhost:5035/api/LogItem/logs/byUser`, {
            method: "GET",
            headers: {
                'Authorization': `Bearer ${session?.user.accessToken}`,
                'Content-Type': 'application/json'
            }
        })

        return await res.json();
    } catch (e) {
        throw e;
    }
}