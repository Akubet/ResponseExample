import { ErrorCode } from "./errorCodes";

const API_URL = process.env.NEXT_PUBLIC_API_URL || "http://localhost:5000";

export interface ValidationError {
  field: string;
  message: string;
}

export interface ApiResponse<T> {
  success: boolean;
  data?: T;
  errorCode?: ErrorCode;
  message?: string;
  validationErrors?: ValidationError[];
}

export async function apiFetch<T>(
  url: string,
  options: RequestInit = {}
): Promise<ApiResponse<T>> {
  const res = await fetch(API_URL + url, {
    ...options,
    headers: {
      "Content-Type": "application/json",
      ...(options.headers || {}),
    },
    credentials: "include",
  });

  let json: ApiResponse<T>;

  try {
    json = await res.json();
  } catch {
    return {
      success: false,
      errorCode: "ServerError",
      message: "Invalid JSON from server",
    };
  }
  return json;
}
