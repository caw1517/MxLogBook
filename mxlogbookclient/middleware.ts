import { auth } from './auth'
import { defaultLoginRedirect, apiAuthPrefix, authRoutes, publicRoutes } from './routes';

export default auth((req) => {
    const { nextUrl } = req;
    const isLoggedIn = !!req.auth;

    const isApiAuthRoute = nextUrl.pathname.startsWith(apiAuthPrefix);
    const isPublicRoute = publicRoutes.includes(nextUrl.pathname);
    const isAuthRoute = authRoutes.includes(nextUrl.pathname);

    if(isApiAuthRoute) {
        //Do no actions
        return null;
    }

    if(isAuthRoute) {
        //Check if logged in
        if(isLoggedIn) {
            return Response.redirect(new URL("/userdashboard", nextUrl));
        }
        return null;
    }

    if(!isLoggedIn && !isPublicRoute) {
        return Response.redirect(new URL("/auth/signin", nextUrl))
    }

    return null;
});

export const config = {
    matcher: ["/((?!.+\\.[\\w]+$|_next).*)", "/", "/(api|trpc)(.*)"],
}