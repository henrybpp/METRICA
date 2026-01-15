export async function createEvent(idToken: string, payload: EventPayload) {
  console.log("createEvent-idToken:" + idToken);
  console.log("createEvent-payload:" + JSON.stringify(payload));
  const res = await fetch("https://localhost:7216/api/events", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      "Authorization": `Bearer ${idToken}`,
    },
    body: JSON.stringify(payload),
  });

  if (!res.ok) throw new Error("Error en la API");
  return res.json();
}
