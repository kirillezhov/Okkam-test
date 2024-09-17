import { useEffect, useState } from 'react';
import { Button, Flex, Table, TableColumnsType } from 'antd';
import moment from 'moment';

import axiosInstance from './utils/axiosInstance.ts';
import { Car } from './models/Car.ts';
import NewCarModal from './components/NewCarModal';
import { BodyType } from './models/BodyType.ts';
import { Brand } from './models/Brand.ts';

interface DataType {
    key: React.Key,
    name: string,
    brand: string,
    bodyType: string,
    seatsCount: number,
    url?: string,
    createdAt: Date,
};

const columns: TableColumnsType<DataType> = [
    { title: 'Модель', dataIndex: 'name' },
    { title: 'Бренд', dataIndex: 'brand' },
    { title: 'Тип кузова', dataIndex: 'bodyType' },
    { title: 'Количество сидений', dataIndex: 'seatsCount' },
    { title: 'Изображение', dataIndex: 'key', render: (id: string) => <a href={`http://localhost:5206/api/cars/image/${id}`} download>Download Image</a> },
    { title: 'Ссылка', dataIndex: 'url', render: (url: string) => <a href={url} target="_blank">{url}</a> },
    { title: 'Создан', dataIndex: 'createdAt', render: (date: Date) => (moment(date)).format('DD-MMM-YYYY HH:mm:ss') },
];

const App = () =>  {
    const [cars, setCars] = useState<Car[]>([]);
    const [bodyTypes, setBodyTypes] = useState<BodyType[]>([]);
    const [brands, setBrands] = useState<Brand[]>([]);
    const [loading, setLoading] = useState<boolean>(false);
    const [error, setError] = useState<string>();
    const [newCarModalVisible, setNewCarModalVisible] = useState<boolean>(false);

    const fetchCars = async () => {
        setLoading(true);

        try {
            const response = await axiosInstance.get<Car[]>('/cars');

            setCars(response.data);
        } catch (err) {
            console.log(err);
            setError('Ошибка при загрузке данных');
        } finally {
            setLoading(false);
        }
    };

    const fetchBodyTypes = async () => {
        try {
            const response = await axiosInstance.get<BodyType[]>('/bodyTypes');

            setBodyTypes(response.data);
        } catch (err) {
            console.log(err);
            setError('Ошибка при загрузке справочника BodyTypes');
        }
    };

    const fetchBrands = async () => {
        try {
            const response = await axiosInstance.get<Brand[]>('/brands');

            setBrands(response.data);
        } catch (err) {
            console.log(err);
            setError('Ошибка при загрузке справочника Brands');
        }
    };

    const dataSource = cars.map<DataType>((car) => ({
        key: car.id,
        bodyType: car.bodyType.name,
        brand: car.brand.name,
        name: car.modelName,
        seatsCount: car.seatsCount,
        url: car.url,
        createdAt: car.createdAt
    }));

    const handleOnCancelModal = async () => {
        setNewCarModalVisible(false);
        await fetchCars();
    }

    useEffect(() => {
        fetchCars();
        fetchBodyTypes();
        fetchBrands();
    }, []);

    return (
        <Flex gap="middle" vertical>
            <Flex align="center" gap="middle">
                <Button type="primary" onClick={() => setNewCarModalVisible(true)}>Новый автомобиль</Button>
            </Flex>
            <Table
                columns={columns}
                dataSource={dataSource}
                rowKey="key"
                loading={loading}
                footer={() => error && <div>Ошибка: {error}</div>}
                pagination={{ pageSize: 10 }}
            />
            <NewCarModal
                visible={newCarModalVisible}
                onCancel={handleOnCancelModal}
                brands={brands}
                bodyTypes={bodyTypes}
            />
        </Flex>
    );
};

export default App;