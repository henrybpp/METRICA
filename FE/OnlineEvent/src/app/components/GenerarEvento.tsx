"use client";

import React from "react";
import { useEvent } from "../hooks/useEvent";

interface GenerateEventProps {
  idToken: string;
}

const GenerarEvento: React.FC<GenerateEventProps> = ({ idToken }) => {
  const { generateEvent, loading, response, error } = useEvent(idToken);

  const lugares = ["Lima", "San Miguel", "La Victoria", "Miraflores"];

  function getRandomName(): string {
    const names = ["Event Spring", "Event new year", "Event Christmas", "Event autumn"];
    return names[Math.floor(Math.random() * names.length)];
  }

  function getRandomLugar(): string {
    return lugares[Math.floor(Math.random() * lugares.length)];
  }

  const handleClick = () => {
    const payload: EventPayload = {
      Nombre: getRandomName(),
      Fecha: new Date().toLocaleDateString("es-PE"),
      Lugar: getRandomLugar(),
      Estado: "A",
    };
    console.log("payload:", payload);
    generateEvent(payload);
  };

  return (
    <div style={{ padding: "1rem", border: "1px solid #ccc" }}>
      <button onClick={handleClick} disabled={loading}>
        {loading ? "Generando..." : "Generar Evento"}
      </button>

      {error && <p style={{ color: "red" }}>❌ {error}</p>}

      {response && (
        <div style={{ marginTop: "1rem" }}>
          <h3>✅ Evento generado:</h3>
          <pre>{JSON.stringify(response, null, 2)}</pre>
        </div>
      )}
    </div>
  );
};

export default GenerarEvento;
