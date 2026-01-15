/*function DashborPage() {
  return (
    <div>DashborPage</div>
  )
}

export default DashborPage*/
"use client";

import { useSession } from "next-auth/react";
import GenerarEvento from "../components/GenerarEvento";

export default function Dashboard() {
  const { data: session, status } = useSession();

  if (status === "loading") {
    return <p>Cargando sesión...</p>;
  }

  const idToken = (session as any)?.idToken;

  return (
    <div>
      {idToken ? (
        <GenerarEvento idToken={idToken} />
      ) : (
        <p>No hay token disponible en la sesión</p>
      )}
    </div>
  );
}

