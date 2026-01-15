import NextAuth from "next-auth";
import GoogleProvider from "next-auth/providers/google";

const handler = NextAuth({
  providers: [
    GoogleProvider({
      clientId: process.env.GOOGLE_CLIENT_ID as string,
      clientSecret: process.env.GOOGLE_CLIENT_SECRET as string,
    }),
  ],
    callbacks: {
    async jwt({ token, account }) {
      // Cuando el usuario hace login inicial
      if (account) {
        token.idToken = account.id_token; // guardamos el id_token en el JWT
      }
      return token;
    },
    async session({ session, token }) {
      // Pasamos el idToken a la sesión para usarlo en el cliente
      (session as any).idToken = token.idToken;
      return session;
    },
  },
});

export { handler as GET, handler as POST };
