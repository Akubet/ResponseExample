import { apiFetch, ApiResponse } from "@/lib/apiClient";
import { ApiError } from "@/lib/apiError";
import { errorMap } from "@/lib/errorMap";

export const userService = {
  async getUser(id: number) {
    const res = await apiFetch<{ id: number; name: string }>(
      `/api/users/${id}`
    );

    if (!res.success) {
      throw new ApiError(res);
    }

    return res.data;
  },
};
