'use client'
import Link from "next/link";
import {useAppSelector} from "@/app/store/store";

export default function DashboardTaskCard() {
    const logState = useAppSelector((state) => state.log.logItems);
    
    const logItems = logState.map((item, index) => (
        <ul className="w-2/3 flex justify-center gap-40 text-left">
            <li>{index + 1}</li>
            <li>{item.discrepency}</li>
            <li>{item.vehicleId}</li>
            <li>{item.closed}</li>
        </ul>

    ));

    return (
        <div className="w/full h-80 bg-bg-light mt-8 p-4 rounded-xl">
            <div className='flex justify-between items-center'>
              <h2 className='text-3xl'>Open MCI's</h2>
              <Link href="/userdashboard/vehicles" className='text-primary-200'>View All</Link>
            </div>
            
            {/*Custom Table*/}
            <div>
                <div className="flex justify-center">
                    <ul className="w-2/3 flex justify-center gap-40 border-b-2 text-left">
                        <li>Index</li>
                        <li>Discrepancy</li>
                        <li>Vehicle</li>
                        <li>Status</li>
                    </ul>
                </div>
                <div>
                    <div className="flex flex-col justify-center items-center">
                        {logItems}
                    </div>
                </div>

            </div>

            {/*<div className="flex justify-center">*/}
            {/* <table className="table-fixed border-collapse border-spacing-6">*/}
            {/*    <thead className="border-b-[1px] table-header-group">*/}
            {/*        <tr>*/}
            {/*            <th>Index</th>*/}
            {/*            <th>Discrepency</th>*/}
            {/*            <th>Vehicle</th>*/}
            {/*            <th>Status</th>*/}
            {/*        </tr>*/}
            {/*    </thead>*/}
            {/*    <tbody className="">*/}
            {/*        {logItems}*/}
            {/*    </tbody>*/}
            {/*</table>*/}
            {/*</div>*/}
  
        </div>
    );
}