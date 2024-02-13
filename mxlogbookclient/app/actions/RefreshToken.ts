import { auth } from "@/auth"

export async function RefreshToken() {
    const session = await auth();

    console.log("Called");
    
    const res = await fetch("http://localhost:5035/api/Auth/refreshtoken", {
        method: "POST",
        body: JSON.stringify({
            userId: session?.user.userId,
            token: session?.user.accessToken,
            refreshToken: session?.user.refreshToken
        }),
        headers: {
            'Content-Type': 'application/json'
        }
    })

    const data = await res.json();

    console.log(data);

    console.log("New Refresh token made");

    if(session) {
        session.user.accessToken = data.token;
        session.user.refreshToken = data.token;
        session.user.refreshTries = 0;
    }

    return null;
}