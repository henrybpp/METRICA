import { useState } from "react";
import { createEvent } from "../services/eventService";
import { EventResponse } from "../types/event";

export function useEvent(idToken: string) {
  const [loading, setLoading] = useState(false);
  const [response, setResponse] = useState<EventResponse | null>(null);
  const [error, setError] = useState<string | null>(null);

  const generateEvent = async (payload: EventPayload) => {
    setLoading(true);
    try {
      const data = await createEvent(idToken, payload);
      setResponse(data);
    } catch (err: any) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  };

  return { generateEvent, loading, response, error };
}
