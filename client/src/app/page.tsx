import { ApiError } from "@/lib/apiError";
import { userService } from "@/services/userService";

export default async function Home() {
  try {
    const user1 = await userService.getUser(1);
    console.log("User 1:", user1);
  } catch (e) {
    if (e instanceof ApiError) {
      console.error("API Error:", e.error);
    } else {
      console.error("Unexpected Error:", e);
    }
  }
  try {
    const user2 = await userService.getUser(-1);
    console.log("User 2:", user2);
  } catch (e) {
    if (e instanceof ApiError) {
      console.error("API Error:", e.error);
    } else {
      console.error("Unexpected Error:", e);
    }
  }
  return (
    <main>
      <h1>Response Example</h1>
    </main>
  );
}
