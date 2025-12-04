import { ApiResponse } from "./apiClient";
import { ErrorCode } from "./errorCodes";

export interface ErrorResponse {
  errorCode: ErrorCode;
  message?: string;
  validationErrors?: { field: string; message: string }[];
}

export class ApiError extends Error {
  public error: ErrorResponse;

  constructor(response: ApiResponse<any>) {
    super("API Error");
    Object.setPrototypeOf(this, ApiError.prototype);
    this.name = "ApiError";

    this.error = {
      errorCode: response.errorCode!,
      message: response.message,
      validationErrors: response.validationErrors,
    };
  }
}
