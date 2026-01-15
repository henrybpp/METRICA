"use client";

import Link from "next/link";
import { signIn, useSession, signOut } from "next-auth/react";

function Navbar() {
  const { data: session } = useSession();
  const idToken = (session as any)?.idToken;
  const isAuthenticated = idToken != null;
  //console.log("session:", session);
  //console.log("idToken-->"+ idToken);
    return (
    <nav className="w-full bg-gray-800 text-white">
      <div className="max-w-7xl mx-auto px-5">
        <div className="grid grid-cols-5 items-center h-16">
          <div className="flex justify-start">
            <Link href="/">
              <span className="cursor-pointer hover:text-yellow-400">Eventos</span>
            </Link>
          </div>
          {isAuthenticated ? (
            <Link href="/dashboard" className="text-blue-600 hover:underline">
              Crear Evento
            </Link>
          ) : (
            <span className="text-gray-400 cursor-not-allowed">
              Crear Evento (requiere SignIn)
            </span>
          )}
          {session?.user ? (
            <div className="flex justify-end">
              <p>Welcome {session.user.name} </p>
            </div>
          ) : (
            <span className="text-gray-400 cursor-not-allowed">
              Welcome
            </span>
          )}
          <div className="flex justify-end">
            <button onClick={() => signIn()} className="bg-sky-400 px-3 py-2 rounded">
                Sign In
            </button>
          </div>
          <div className="flex justify-end">
            <button disabled={!isAuthenticated}
              onClick={async () => {
                await signOut({
                  callbackUrl: "/",
                })
              }}
              className={`px-3 py-2 rounded text-white ${isAuthenticated ? "bg-sky-400 hover:bg-sky-500" : "bg-sky-200 cursor-not-allowed"} `}>Logout
            </button>
          </div>
        </div>
      </div>
    </nav>
  );
};
export default Navbar;
