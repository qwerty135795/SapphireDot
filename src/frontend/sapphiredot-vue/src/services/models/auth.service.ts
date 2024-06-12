import {Environment} from "@/env";

export function login(request: {username:string, password:string}) {
    fetch(Environment.API)
}