import type { ErrorCode } from "./errorCodes";

export const errorMap: Record<ErrorCode, string> = {
  Unauthorized: "Need Authentication",
  Forbidden: "Access Denied",
  NotFound: "Not Found",
  ValidationError: "Validation Error",
  Conflict: "Conflict Detected",
  ServerError: "Server Error",
};
