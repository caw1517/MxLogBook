import { jwtDecode } from "jwt-decode";
import NextAuth from "next-auth";
import Credentials from "next-auth/providers/credentials";
import { decode } from "punycode";

export const {
    handlers: { GET, POST },
    auth,
    signIn,
    signOut
} = NextAuth({
    providers: [
        Credentials({
            async authorize(credentials) {

                const res = await fetch("http://localhost:5035/api/Auth/login",  {
                    method: "POST",
                    body: JSON.stringify(credentials),
                    headers: { "Content-Type": "application/json" }
                });

                const user = await res.json();

                if(user && res.status == 200) {
                    return { 
                        id: user.userId,
                        accessToken: user.token,
                        refreshToken: user.refreshToken

                     }
                }
                
                return null; 
            }
        })
    ],
    session: { strategy: "jwt"},
    callbacks: {
        async jwt({ token, user, account }){
            if(user) {
                token.accessToken = user.accessToken;
                token.refreshToken = user.refreshToken;
            }          

            //Decode the token to get the exp time
            const decoded = jwtDecode(token?.accessToken as string);

            //If token is still not expired return it and do nothing
            if(decoded.exp !== undefined && decoded.exp * 1000 > Date.now()) {
                return token;
            }

            await refreshAccessToken(token);

            return token;
            
        },
        async session({ token, session }) {
            if(session.user && token.sub) {
                (session.user as any).userId = token.sub;
                (session.user as any).accessToken = token.accessToken;
                (session.user as any).refreshToken = token.refreshToken;
            }

            return session;
        }
    }
});

async function refreshAccessToken(token: any) {

    try {
        //Query the api
        const response = await fetch("http://localhost:5035/api/Auth/refreshtoken", {
            method: "POST",
            body: JSON.stringify({
                userId: token.sub,
                token: token.accessToken,
                refreshToken: token.refreshToken
            }),
            headers: {
                "Content-Type": "application/json"
            }
        })

        //Get the new tokens
        const refreshedTokens = await response.json();

        if(!response.ok) {
            throw refreshedTokens;
        }

        token.accessToken = refreshedTokens.token;
        token.refreshToken = refreshedTokens.refreshToken;

    } catch (error) {
        return error;
    }
}