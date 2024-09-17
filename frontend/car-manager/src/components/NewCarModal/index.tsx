import { useState } from 'react';
import { AxiosError } from 'axios';
import { UploadOutlined } from '@ant-design/icons';

import {
    Modal,
    Form,
    Input,
    Select,
    InputNumber,
    Upload,
    Button,
    UploadFile,
    FormProps,
    UploadProps,
    Typography
} from 'antd';
import { Brand } from '../../models/Brand.ts';
import { BodyType } from '../../models/BodyType.ts';
import axiosInstance from '../../utils/axiosInstance.ts';
import { toBase64String } from '../../utils/FileUtils.ts';
import { CarManagerError } from '../../models/CarManagerError.ts';

interface NewCarModalProps {
    visible: boolean;
    onCancel: () => void;
    brands: Brand[];
    bodyTypes: BodyType[]
}

interface FieldType {
    brand: string;
    model: string;
    bodyType: string;
    seatsCount: number;
    url?: string;
    fileList: UploadFile[];
}

const NewCarModal = (props: NewCarModalProps) => {
    const { visible, onCancel, brands, bodyTypes } = props;
    const [fileList, setFileList] = useState<UploadFile[]>([]);
    const [loading, setLoading] = useState<boolean>(false);
    const [error, setError] = useState<string>();

    const [form] = Form.useForm();

    const brandOptions = brands.map(brand => ({ value: brand.id, label: brand.name }));
    const bodyTypesOptions = bodyTypes.map(bodyType => ({ value: bodyType.id, label: bodyType.name }));

    const onFinish: FormProps<FieldType>['onFinish'] = async (values) => {
        const imageInBase64 = await toBase64String(values.fileList[0].originFileObj!);

        await createCar(values.brand, values.bodyType, values.model, values.seatsCount, imageInBase64, values.url);
    };

    const uploadProps: UploadProps = {
        accept: 'image/png, image/jpeg',
        onRemove: (file) => {
            const index = fileList.indexOf(file);
            const newFileList = fileList.slice();

            newFileList.splice(index, 1);
            setFileList(newFileList);
        },
        beforeUpload: (file) => {
            setFileList([...fileList, file]);

            return false;
        },
        fileList,
    };

    const handleOnCancel = () => {
        form.resetFields();
        setFileList([]);
        setError(undefined)
        onCancel();
    };

    const createCar = async (brandId: string, bodyTypeId: string, modelName: string, seatsCount: number, imageInBase64: string, url?: string) => {
        setLoading(true);

        try {
            await axiosInstance.post('/cars', {
                brandId,
                bodyTypeId,
                modelName,
                seatsCount,
                imageInBase64,
                url
            });
            handleOnCancel();
        }
        catch (err) {
            const errorResponse = err as AxiosError;
            const carManagerError = errorResponse.response?.data as CarManagerError;

            setError(carManagerError?.message);
        }
        finally {
            setLoading(false);
        }

    }

    return (
        <Modal
            title="Новый автомобиль"
            open={visible}
            onOk={() => {
                setError(undefined);
                form.submit();
            }}
            onCancel={handleOnCancel}
            okButtonProps={{
                loading: loading,
                disabled: loading,
            }}
            cancelButtonProps={{
                disabled: loading,
            }}
        >
            <Form
                form={form}
                labelCol={{ span: 8 }}
                wrapperCol={{ span: 16 }}
                autoComplete="off"
                onFinish={onFinish}
                disabled={loading}
            >
                <Form.Item<FieldType>
                    label="Марка"
                    name="brand"
                    rules={[{ required: true }] }
                >
                    <Select options={brandOptions}></Select>
                </Form.Item>
                <Form.Item<FieldType>
                    label="Модель"
                    name="model"
                    rules={[{ required: true }] }
                >
                    <Input placeholder="Введите модель автомобиля" />
                </Form.Item>
                <Form.Item<FieldType>
                    label="Тип кузова"
                    name="bodyType"
                    rules={[{ required: true }] }
                >
                    <Select options={bodyTypesOptions}></Select>
                </Form.Item>
                <Form.Item<FieldType>
                    label="Количество сидений"
                    name="seatsCount"
                    rules={[{ required: true, type: 'number', min: 6, max: 12 }] }
                >
                    <InputNumber />
                </Form.Item>
                <Form.Item<FieldType>
                    label="Изображение"
                    name="fileList"
                    valuePropName="file"
                    getValueFromEvent={e => e.fileList}
                    rules={[{ required: true }]}
                >
                    <Upload {...uploadProps}>
                        <Button icon={<UploadOutlined />}>Выбрать</Button>
                    </Upload>
                </Form.Item>
                <Form.Item<FieldType>
                    label="Ссылка"
                    name="url"
                    rules={[{ type: 'url' }] }
                >
                    <Input />
                </Form.Item>
            </Form>
            {error && <Typography.Text style={{ color:'red' }}>{error}</Typography.Text>}
        </Modal>
    );
}

export default NewCarModal;