// next-auth.d.ts
import 'next-auth';

declare module 'next-auth' {
  /**
   * Extends the built-in session.user type
   * with additional properties.
   */
  interface User {
    accessToken?: string;
    refreshToken?: string;
  }

  /**
   * Adds additional properties to the session
   * This is useful if you want to access the properties client-side.
   */
  interface Session {
    user: {
      accessToken?: string;
      refreshToken?: string;
      // Add any other properties you need in the session
    } & User;
  }
}

declare module 'next-auth/jwt' {
  /** Extends the JWT type for NextAuth with custom properties */
  interface JWT {
    accessToken?: string;
    refreshToken?: string;
    // Add any other properties you've included in the JWT
  }
}
