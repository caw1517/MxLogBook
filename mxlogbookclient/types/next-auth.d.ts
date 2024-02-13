// types/next-auth.d.ts
import 'next-auth';

declare module 'next-auth' {
  /**
   * Extends the built-in session/user types with the accessToken and refreshToken
   */
  interface User {
    token?: string;
    refreshToken?: string;
    accessToken?: string;
  }
  
  // If you are also customizing session or account, you can extend those types as well
  interface Session {
    user?: {
      accessToken?: string;
      refreshToken?: string;
      userId?: string;
    } & DefaultSession['user'];
  }
}
