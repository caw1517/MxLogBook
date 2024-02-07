import { NextRequest, NextResponse } from "next/server";
import { cookies } from "next/headers";
export async function POST(req: NextRequest, res: NextResponse) {

    //Pull data from the request
    const data = await req.json();


    //Call the api
    try {

        //Call the api - Move the base api string somewhere else
        const response = await fetch('http://localhost:5035/api/Auth/login', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({email: data.email, password: data.password})
        });
        
        const resData = await response.json();

        if(response.ok) {
            cookies().set("authData", JSON.stringify({
                token: resData.token,
                refreshToken: resData.refreshToken
            }), {
                httpOnly: true,
                maxAge: 60*60**24*7,
                path: '/'
        })
            return NextResponse.json({Test: "Test"});
        } else {
            return NextResponse.json({error: resData})
        }
    } catch (e) {
        return NextResponse.json({error: e})   
    }
}