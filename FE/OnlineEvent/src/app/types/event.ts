export interface EventPayload {
  Nombre: string;
  Fecha: string;
  Lugar: string;
  Estado: string;
};

// Request para crear un evento
export interface CreateEventRequest {
  name: string;
  date: string;      // ISO string: 2026-01-20
  location?: string;
}

// Response del backend
export interface EventResponse {
  id: string;
  name: string;
  date: string;
  location?: string;
  createdBy: string;
  createdAt: string;
}

// Modelo base (opcional, reutilizable)
export interface Event {
  id: string;
  name: string;
  date: string;
  location?: string;
}
