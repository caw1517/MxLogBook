import Image from "next/image"
import Apps from "@/public/apps.svg";
import Notifications from "@/public/notifications.svg"

export default function UserNavbar() {
    return(
        <div className="flex justify-center">
            <div className="w-2/3 h-16 bg-bg-light my-8 rounded-md flex items-center px-4 justify-between">
                <div className="cursor-pointer">Search</div>

                <div className="flex gap-4">
                    <Image src={Apps} alt="Apps" height={30} className="cursor-pointer hover:scale-110 transition-all" />
                    <Image src={Notifications} alt="Notifications" height={30} className="cursor-pointer hover:scale-110 transition-all"/>
                    <div className="h-10 w-10 bg-primary-200 rounded-[50%] cursor-pointer hover:scale-110 transition-all flex justify-center items-center">
                        C
                    </div>
                </div>
            </div>
        </div>
    )
}