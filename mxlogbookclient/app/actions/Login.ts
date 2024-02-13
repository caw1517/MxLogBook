'use server'
import { signIn } from "@/auth"
import { defaultLoginRedirect } from "@/routes"
import { AuthError } from "next-auth"

export async function Login(email?: string, password?: string) {
    try {
        await signIn("credentials", {
            email,
            password, 
            redirectTo: defaultLoginRedirect
        })
    } catch (error) {
        if(error instanceof AuthError) {
            switch(error.type) {
                case 'CredentialsSignin':
                    return { error: "Invalid Credentials" }
                default: 
                    return { error: "Something went wrong" }
            }
        }

        throw error;
    }
}