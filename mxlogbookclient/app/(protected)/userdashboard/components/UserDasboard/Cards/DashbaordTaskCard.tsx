import Link from "next/link";

export default function DashboardTaskCard() {
    
    return (
        <div className="w/full h-80 bg-bg-light mt-8 p-4 rounded-xl">
            <div className='flex justify-between items-center'>
              <h2 className='text-3xl'>Open MCI's</h2>
              <Link href="/userdashboard/vehicles" className='text-primary-200'>View All</Link>
            </div>
            <div className="flex justify-center">
             <table className="table-fixed border-collapse border-spacing-6">
                <thead className="border-b-[1px] table-header-group">
                    <tr>
                        <th>Index</th>
                        <th>Discrepency</th>
                        <th>Vehicle</th>
                        <th>Company</th>
                    </tr>
                </thead>
                <tbody className="">
                    <tr>
                        <td>1.</td>
                        <td>1.</td>
                        <td>1.</td>
                        <td>1.</td>
                    </tr>
                </tbody>
            </table>
            </div>
  
        </div>
    );
}